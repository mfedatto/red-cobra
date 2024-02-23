cy.redCobra = {
    userAssertion: (sourceUser, referenceUser) => {
        expect(sourceUser).to.be.an('object');
        expect(sourceUser.userId).to.not.be.eq(null);
        expect(sourceUser.username).to.not.be.eq(null);
        expect(sourceUser.admin).to.not.be.eq(null);
        expect(sourceUser.userId).to.not.be.eq(undefined);
        expect(sourceUser.username).to.not.be.eq(undefined);
        expect(sourceUser.admin).to.not.be.eq(undefined);
        expect(sourceUser.userId).to.be.an('string');
        expect(sourceUser.username).to.be.an('string');
        expect(sourceUser.admin).to.be.an('boolean');
        expect(sourceUser.userId).to.be.eq(referenceUser.userId);
        expect(sourceUser.username).to.be.eq(referenceUser.username);
        expect(sourceUser.admin).to.be.eq(referenceUser.admin);
        
        if (sourceUser.fullname) {
            expect(sourceUser.fullname).to.be.an('string');
            expect(sourceUser.fullname).to.be.eq(referenceUser.fullname);
        }

        if (sourceUser.email) {
            expect(sourceUser.email).to.be.an('string');
            expect(sourceUser.email).to.be.eq(referenceUser.email);
        }
    }
};
