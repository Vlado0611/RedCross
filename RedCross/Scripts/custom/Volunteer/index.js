
function deleteVolunteer(id) {
    if (confirm("Are you sure ?")) {
        let url = `${window.origin}/Volunteer/DeleteVolunteer/${id}`;
        window.location.href = url;
    }
}