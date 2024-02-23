import users from '../fixtures/a1tier-users.json';
import '../support/functions.js';

const uuidPattern =
  /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

describe('Tier A1 - Default Dataset: /v1/users', () => {
  users.forEach((user) => {
    let userIdToDelete = user.userId;

    it(`Gets a user (${user.username})`, () => {
      cy.request({
        method: 'GET',
        url: `/v1/users?username=${user.username}`,
      }).then((response) => {
        expect(response.status).to.eq(200);
        cy.redCobra.pagedListWrapperAssertions(response.body);
        expect(response.body.payload.length).to.be.lt(2);

        if (response.body.payload.length > 0) {
          expect(response.body.payload[0]).to.be.an('object');
          expect(response.body.payload[0].userId).to.match(uuidPattern);

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
        cy.redCobra.userAssertions(response.body, user);
      });
    });
  });
  it('Gets a list of users', () => {
    cy.request({
      method: 'GET',
      url: '/v1/users',
    }).then((response) => {
      expect(response.status).to.eq(200);
      cy.redCobra.pagedListWrapperAssertions(response.body);

      if (response.body.payload.length > 0) {
        response.body.payload.forEach((user) => {
          cy.redCobra.userAssertions(user);
        });
      }
    });
  });
});
