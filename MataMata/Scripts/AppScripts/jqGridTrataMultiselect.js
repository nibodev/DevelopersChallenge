cellValues = [];
var $Grid = {

    getAllSelectedItems: function (gridName, columnID) {
        var $grid = $("#" + gridName), selIds = $grid.jqGrid("getGridParam", "selarrrow"), i, n;

        for (i = 0, n = selIds.length; i < n; i++) {
            var item = $grid.jqGrid("getCell", selIds[i], columnID)
            if (item != 'false' && item != null) {
                cellValues.push(item);
            }

        }
        return cellValues;
    }
}