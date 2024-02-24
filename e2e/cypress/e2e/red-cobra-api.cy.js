import users from '../fixtures/a1tier-users.json';
import rc from '../support/red-cobra.js';

describe('Tier A1 - Default Dataset: /v1/users', () => {
  users.forEach((user) => {
    let userIdToDelete = user.userId;

    it(`gets users list by username (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users?username=${user.username}`,
      }).then((response) => {
        expect(response.status).to.eq(200);
        rc.assertions.pagedListWrapper(response.body);
        expect(response.body.payload.length).to.be.lt(2);

        if (response.body.payload.length > 0) {
          expect(response.body.payload[0]).to.be.an('object');
          expect(response.body.payload[0].userId).to.match(rc.patterns.uuid);

          userIdToDelete = response.body.payload[0].userId;
        }
      });
    });

    it(`excludes a user (${user.username})`, () => {
      cy.request({
        method: 'DELETE',
        url: `/v1/users/${userIdToDelete}`,
        failOnStatusCode: false,
      }).then((response) => {
        expect([200, 404, 409]).to.contain(response.status);
      });
    });

    it(`creates a user (${user.username})`, () => {
      cy.request({
        method: 'POST',
        url: '/v1/users',
        body: {
          userId: user.userId,
          credentials: btoa(`${user.username}:${user.password}`),
          admin: user.admin,
          fullname: user.fullname,
          email: user.email,
        },
      }).then((response) => {
        expect(response.status).to.eq(200);
        rc.assertions.user(response.body, user);
      });
    });

    it(`gets a user (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users/${user.userId}`,
        failOnStatusCode: false,
      }).then((response) => {
        expect(response.status).to.eq(200);
        rc.assertions.user(response.body, user);
      });
    });

    it(`gets a user licenses (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users/${user.userId}/licenses`,
        failOnStatusCode: false,
      }).then((response) => {
        expect(response.status).to.eq(200);
        expect(response.body).to.be.an('array');
        expect(response.body.length).to.be.eq(0);
      });
    });

    if (user.licenses) {
      user.licenses.forEach((license) => {
        it(`creates a user license (${user.username}: ${license.licenseNumber})`, () => {
          cy.request({
            method: 'POST',
            url: `/v1/users/${user.userId}/licenses`,
            body: {
              "licenseId": license.licenseId,
              "licenseNumber": license.licenseNumber,
              "expirationDate": license.expirationDate,
              "aCategory": license.aCategory,
              "bCategory": license.bCategory,
              "dateOfBirth": license.dateOfBirth,
              "licenseFileId": license.licenseFileId,
              "issuer": license.issuer,
              "issueDate": license.issueDate
            },
            failOnStatusCode: false,
          }).then((response) => {
            expect(response.status).to.eq(200);
            rc.assertions.license(user.userId, response.body, license);
          });
        });
      });
    }

  });

  it('gets a list of users', () => {
    cy.request({
      method: 'GET',
      url: '/v1/users',
    }).then((response) => {
      expect(response.status).to.eq(200);
      rc.assertions.pagedListWrapper(response.body);

      if (response.body.payload.length > 0) {
        response.body.payload.forEach((user) => {
          rc.assertions.user(user);
        });
      }
    });
  });
});
