
function deleteAction(id) {
    if (confirm("Are you sure ?")) {
        let url = `${window.origin}/Action/DeleteAction/${id}`;
        window.location.href = url;
    }
}