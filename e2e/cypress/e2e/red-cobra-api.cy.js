import users from '../fixtures/a1tier-users.json';
import '../support/constants.js';
import '../support/functions.js';

describe('Tier A1 - Default Dataset: /v1/users', () => {
  users.forEach((user) => {
    let userIdToDelete = user.userId;

    it(`Gets users list by username (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users?username=${user.username}`,
      }).then((response) => {
        expect(response.status).to.eq(200);
        cy.rcFunctions.pagedListWrapperAssertions(response.body);
        expect(response.body.payload.length).to.be.lt(2);

        if (response.body.payload.length > 0) {
          expect(response.body.payload[0]).to.be.an('object');
          expect(response.body.payload[0].userId).to.match(cy.rcConstants.uuidPattern);

          userIdToDelete = response.body.payload[0].userId;
        }
      });
    });

    it(`Excludes a user (${user.username})`, () => {
      cy.request({
        method: 'DELETE',
        url: `/v1/users/${userIdToDelete}`,
        failOnStatusCode: false,
      }).then((response) => {
        expect([200, 404, 409]).to.contain(response.status);
      });
    });

    it(`Creates a user (${user.username})`, () => {
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
        cy.rcFunctions.userAssertions(response.body, user);
      });
    });

    it(`Gets a user (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users/${user.userId}`,
        failOnStatusCode: false,
      }).then((response) => {
        expect(response.status).to.eq(200);
        cy.rcFunctions.userAssertions(response.body, user);
      });
    });

    it(`Gets a user licenses (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users/${user.userId}/licenses`,
        failOnStatusCode: false,
      }).then((response) => {
        expect(response.status).to.eq(200);
        cy.rcFunctions.userAssertions(response.body, user);
      });
    });

  });

  it('Gets a list of users', () => {
    cy.request({
      method: 'GET',
      url: '/v1/users',
    }).then((response) => {
      expect(response.status).to.eq(200);
      cy.rcFunctions.pagedListWrapperAssertions(response.body);

      if (response.body.payload.length > 0) {
        response.body.payload.forEach((user) => {
          cy.rcFunctions.userAssertions(user);
        });
      }
    });
  });
});
