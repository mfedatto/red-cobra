class RedCobra {
    patterns = {
        uuid: /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i
    };
    assertions = {
        user: (actual, expected) => {
            expect(actual).to.be.an("object");
            expect(actual.userId).to.not.be.eq(null);
            expect(actual.username).to.not.be.eq(null);
            expect(actual.admin).to.not.be.eq(null);
            expect(actual.userId).to.not.be.eq(undefined);
            expect(actual.username).to.not.be.eq(undefined);
            expect(actual.admin).to.not.be.eq(undefined);
            expect(actual.userId).to.be.match(this.patterns.uuid);
            expect(actual.username).to.be.an("string");
            expect(actual.admin).to.be.an("boolean");

            if (expected) {
                expect(actual.userId).to.be.eq(expected.userId);
                expect(actual.username).to.be.eq(expected.username);
                expect(actual.admin).to.be.eq(expected.admin);
            }

            if (actual.fullname) {
                expect(actual.fullname).to.be.an("string");

                if (expected)
                    expect(actual.fullname).to.be.eq(expected.fullname);
            }

            if (actual.email) {
                expect(actual.email).to.be.an("string");

                if (expected)
                    expect(actual.email).to.be.eq(expected.email);
            }
        },
        license: (userId, actual, expected) => {
            expect(actual).to.be.an("object");
            expect(actual.licenseId).to.not.be.eq(null);
            expect(actual.licenseNumber).to.not.be.eq(null);
            expect(actual.userId).to.not.be.eq(null);
            expect(actual.expirationDate).to.not.be.eq(null);
            expect(actual.aCategory).to.not.be.eq(null);
            expect(actual.bCategory).to.not.be.eq(null);
            expect(actual.dateOfBirth).to.not.be.eq(null);
            expect(actual.licenseId).to.not.be.eq(undefined);
            expect(actual.licenseNumber).to.not.be.eq(undefined);
            expect(actual.userId).to.not.be.eq(undefined);
            expect(actual.expirationDate).to.not.be.eq(undefined);
            expect(actual.aCategory).to.not.be.eq(undefined);
            expect(actual.bCategory).to.not.be.eq(undefined);
            expect(actual.dateOfBirth).to.not.be.eq(undefined);
            expect(actual.licenseId).to.be.match(this.patterns.uuid);

            expect(actual.licenseNumber).to.be.an("string");
            expect(actual.userId).to.be.match(this.patterns.uuid);

            expect(actual.expirationDate).to.be.an("string");
            expect(actual.aCategory).to.be.an("boolean");
            expect(actual.bCategory).to.be.an("boolean");
            expect(actual.dateOfBirth).to.be.an("string");

            if (expected) {
                expect(actual.licenseId).to.be.eq(expected.licenseId);
                expect(actual.licenseNumber).to.be.eq(expected.licenseNumber);
                expect(actual.userId).to.be.eq(userId);
                expect(actual.expirationDate).to.be.eq(expected.expirationDate);
                expect(actual.aCategory).to.be.eq(expected.aCategory);
                expect(actual.bCategory).to.be.eq(expected.bCategory);
                expect(actual.dateOfBirth).to.be.eq(expected.dateOfBirth);
            }

            if (actual.licenseFileId) {
                expect(actual.licenseFileId).to.not.be.eq(null);
                expect(actual.licenseFileId).to.not.be.eq(undefined);
                expect(actual.licenseFileId).to.be.match(this.patterns.uuid);

                if (expected)
                    expect(actual.licenseFileId).to.be.eq(expected.licenseFileId);
            }

            if (actual.issuer) {
                expect(actual.issuer).to.not.be.eq(null);
                expect(actual.issuer).to.not.be.eq(undefined);
                expect(actual.issuer).to.be.an("string");

                if (expected)
                    expect(actual.issuer).to.be.eq(expected.issuer);
            }

            if (actual.issueDate) {
                expect(actual.issueDate).to.not.be.eq(null);
                expect(actual.issueDate).to.not.be.eq(undefined);
                expect(actual.issueDate).to.be.an("string");

                if (expected)
                    expect(actual.issueDate).to.be.eq(expected.issueDate);
            }
        },
        pagedListWrapper: (wrapper) => {
            expect(wrapper).to.be.an('object');
            expect(wrapper.total).to.not.be.eq(null);
            expect(wrapper.total).to.not.be.eq(undefined);
            expect(wrapper.total).to.be.an('number');
            expect(wrapper.skip).to.not.be.eq(null);
            expect(wrapper.skip).to.not.be.eq(undefined);
            expect(wrapper.skip).to.be.an('number');
            expect(wrapper.limit).to.not.be.eq(null);
            expect(wrapper.limit).to.not.be.eq(undefined);
            expect(wrapper.limit).to.be.an('number');
            expect(wrapper.payload).to.not.be.eq(null);
            expect(wrapper.payload).to.not.be.eq(undefined);
            expect(wrapper.payload).to.be.an('array');
        }
    };
}

export default new RedCobra();
