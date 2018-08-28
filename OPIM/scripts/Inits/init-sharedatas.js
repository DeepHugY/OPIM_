$(function () {
    $.ajax({
        datatype: 'json',
        type: 'post',
        url: '/Others/GetShareDatas',
        data: {},
        success: function (result) {
            if (result.Success) {
                fileFun.fileMemberShip(result.MemberShip);
                fileFun.fileAnnouncementList(result.AnnList);
            } else {

            }
        },
    });

})

var fileFun = (function () {
    var fileMemberShip = function (memberShip) {
        $('#shareIcon').attr('src', memberShip.Icon != null ? memberShip.Icon : "/Image/user.jpg");
        $('#shareNickName').html(memberShip.NickName);
        $('#shareAge').html("账龄：" + memberShip.OPIMAge + " 天");
        $('#shareOut').html(memberShip.CurrMonthOut+" ");
        $('#shareIn').html(memberShip.CurrMonthIn+" ");
    };

    var fileAnnouncementList = function (annList) {

    };
    return {
        fileMemberShip: fileMemberShip,
        fileAnnouncementList: fileAnnouncementList
    };

})();