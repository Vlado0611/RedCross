
$(document).ready(function () {
    $('.search-container').hide();
    $('.tables').hide();

    $(document).on('change', '#table-select', function () {
        $('.tables').hide();
        let table = $('#table-select').val();
        $('.search-container').show();
        switch (table) {
            case 'action-table':
                $('.action-table').show();
                break;
            case 'volunteer-table':
                $('.volunteer-table').show();
                break;
            case 'beneficiary-table':
                $('.beneficiary-table').show();
                break;
            case 'employee-table':
                $('.employee-table').show();
                break;

            default:
                $('.search-container').hide();
        }
    })
    
})