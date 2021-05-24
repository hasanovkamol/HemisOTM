"use strict";
$(function () {
    $('.actions-list > li').on('click', '.check', function (e) {
        e.preventDefault();
        $(this).parents('.tasks-item')
            .find('.checkbox')
            .prop("checked", true);
        removeActionList();
    });
});
//# sourceMappingURL=tasks.js.map