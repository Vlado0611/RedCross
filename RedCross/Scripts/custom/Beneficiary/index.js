

function deleteBeneficiary(id) {
    if (confirm("Are you sure ?")) {
        let url = `${window.origin}/Beneficiary/DeleteBeneficiary/${id}`;
        window.location.href = url;
    }
}