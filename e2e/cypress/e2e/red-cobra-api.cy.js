describe('GET /users', () => {
  it('Gets a list of users', () => {
    cy.request({
      method: 'GET',
      url: '/v1/users'
    })
      .then((response) => {
        expect(response.status).to.eq(200);
        expect(response.body).to.be.an('object');
        expect(response.body.total).to.not.be.eq(null);
        expect(response.body.skip).to.not.be.eq(null);
        expect(response.body.limit).to.not.be.eq(null);
        expect(response.body.payload).to.not.be.eq(null);
        expect(response.body.payload).to.be.an('array');
      });
  });
});
