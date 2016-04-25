'use strict';

var context;
var web;
var user;
var currentItem;
var hostweburl;
var appweburl;
var title;

function doSearch() {
    var query = $('#txtSearch').val();
    getSearchResults(query);

}

function getSearchResults(queryText) {
    $('#search-title').text("Resultados de la busqueda para [ " + queryText + "]");

    var searchURL = appweburl + "/_api/search/query?querytext='" + queryText + "'&trimduplicates=false";

    var executor = new SP.RequestExecutor(appweburl);

    executor.executeAsync({
        url: searchURL,
        method: "GET",
        headers: { "Accept": "application/json; odata=verbose" },
        success: onGetSearchResultsSuccess,
        error: onGetSearchResultsFail

    });

};

function onGetSearchResultsSuccess(data) {

    var jsonObject = JSON.parse(data.body);

    var results = jsonObject.d.query.PrimaryQueryResult.RelevantResults.Table.Rows.results;

    if (results.length == 0) {
        $("#search-results").text("No hemos encontrado ningun Item, artista");
    } else {
        var searchResultsHtml = "";
        $.each(results, function (index, result) {

        });

    }
}