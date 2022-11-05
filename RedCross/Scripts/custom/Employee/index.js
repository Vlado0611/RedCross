
function deleteEmployee(id) {
    if (confirm("Are you sure ?")) {
        let url = `${window.origin}/Employee/DeleteEmployee/${id}`;
        window.location.href = url;
    }
}