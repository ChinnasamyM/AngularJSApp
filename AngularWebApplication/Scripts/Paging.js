
var module = angular.module("example", ["agGrid"]);
//
module.controller("exampleCtrl", function ($scope, $http) {

    var columnDefs = [
        // this row just shows the row index, doesn't use any data from the row
        {
            headerName: "#", width: 50, cellRenderer: function (params) {
                return params.node.id + 1;
            }
        },
        { headerName: "Name", field: "Name", width: 150, editable: true },
        { headerName: "Age", field: "Age", width: 90 },
        { headerName: "Country", field: "Country", width: 120, editable: true, newValueHandler: numberNewValueHandle },
        { headerName: "Year", field: "Year", width: 90 },
        { headerName: "Date", field: "Date", width: 110 }
        
    ];

    $scope.pageSize = '10';

    $scope.gridOptions = {
        // note - we do not set 'virtualPaging' here, so the grid knows we are doing standard paging
        enableSorting: true,
        enableFilter: true,
        enableColResize: true,
        
        columnDefs: columnDefs
    };

    $scope.onPageSizeChanged = function () {
        createNewDatasource();
    };

    // when json gets loaded, it's put here, and  the datasource reads in from here.
    // in a real application, the page will be got from the server.
    var allOfTheData;
    
    $http.get("../Home/get")
      .then(function (result) {
          
          allOfTheData = result.data;
          createNewDatasource();
      });

    //$http.get("../olympicWinners.json")
    //    .then(function (result) {
    //        allOfTheData = result.data;
    //        createNewDatasource();
    //    });

    function numberNewValueHandle(s) {
        debugger;
        var dat = s.data;
        var _newValue = s.newValue;
        var _oldValue = s.oldValue;// old values can be obtained by using s.data["columnName"]
        var _rowIndex = s.rowIndex;
        alert("value changed rows at " + _rowIndex + " from " + '"' + _oldValue + '"' + " to " + '"' + _newValue + '"' + ".");
        return false;
    };

    function createNewDatasource() {
        if (!allOfTheData) {
            // in case user selected 'onPageSizeChanged()' before the json was loaded
            return;
        }

        var dataSource = {

            //rowCount: ???, - not setting the row count, infinite paging will be used
            pageSize: parseInt($scope.pageSize), // changing to number, as scope keeps it as a string
            getRows: function (params) {
                
                // this code should contact the server for rows. however for the purposes of the demo,
                // the data is generated locally, a timer is used to give the experience of
                // an asynchronous call
                console.log('asking for ' + params.startRow + ' to ' + params.endRow);
                setTimeout(function () {
                    
                    // take a chunk of the array, matching the start and finish times
                    var rowsThisPage = allOfTheData.slice(params.startRow, params.endRow);
                    // see if we have come to the last page. if we have, set lastRow to
                    // the very last row of the last page. if you are getting data from
                    // a server, lastRow could be returned separately if the lastRow
                    // is not in the current page.
                    var lastRow = -1;
                    if (allOfTheData.length <= params.endRow) {
                        lastRow = allOfTheData.length;
                    }
                    params.successCallback(rowsThisPage, lastRow);
                }, 500);
            }
        };
        
        $scope.gridOptions.api.setDatasource(dataSource);
    }
});
