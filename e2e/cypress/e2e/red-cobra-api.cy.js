describe('Red Cobra API testing', () => {
  it('Fetches all users', () => {
    cy.request('http://localhost:5081/v1/users')
  })
})
