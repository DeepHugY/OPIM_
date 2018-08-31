$(function () {
    var selectedYear = $('#selectedYear');
    var selectedMonth = $('#selectedMonth');
    var selectedDay = $('#selectedDay');
    var nowDate = new Date();
    if (selectedYear.length > 0) {
        var year = nowDate.getFullYear();
        selectedYear.find('option[value="' + year + '"]').attr('selected', 'selected');
    };
    if (selectedMonth.length > 0) {
        var month = nowDate.getMonth() + 1;
        selectedMonth.find('option[value="' + month + '"]').attr('selected', 'selected');
    };
    if (selectedDay.length > 0) {
        var day = nowDate.getDate();
        selectedDay.find('option[value="' + day + '"]').attr('selected', 'selected');
    };
});




function ConverDate(date) {
    if (date < 10)
        return "0" + date;
}