var NetworkUtils = (function () {

    //test
    return {
        TestService: {
            renderWeatherCast: function show(showall) {
                //var jqxhr =
                $.ajax
                (
                    {
                        url: "https://localhost:44315/WeatherForecast",
                        statusCode:
                            { 404: function () { alert("page not found"); } }
                    }
                ).done(function (Data) {
                        $('#items').empty();
                        //alert(showall);
                        $.each(Data, function (index, val) {
                            //alert(key);
                            //index is the item index start from zero
                            var date = val.date.toString().substring(0, 10);
                            var filter = $('#itId').val();
                            //debugger;
                            var str = date + ': weather:(' + val.summary + ') - Tempr: ' + val.temperatureC;
                            if (str.indexOf(filter) > -1 || showall == 1 || filter == '') {
                                $('<li/>', { text: str }).appendTo($('#items'));
                            }
                        });

                        //alert("success");

                    })
                    .fail(function (json) {
                        //debugger;
                        //alert("error:" + json.status);

                    })
                    .always(function () {
                        //alert("on always : complete");
                    });
            },
            renderWeatherCast2: function show2(showall) {
                $.ajax("https://localhost:44315/WeatherForecast")
                    .done(function (Data) {

                        $('#items').empty();
                        //alert(showall);
                        $.each(Data, function (index, val) {
                            //alert(key);
                            //index is the item index start from zero
                            var date = val.date.toString().substring(0, 10);
                            var filter = $('#itId').val();
                            //debugger;
                            var str = date + ': weather:(' + val.summary + ')';
                            if (str.indexOf(filter) > -1 || showall == 1 || filter == '') {
                                $('<li/>', { text: str }).appendTo($('#items'));
                            }
                        });

                        //alert("success");

                    })
                    .fail(function (json) {
                        //debugger;
                        //alert("error:" + json.status);

                    })
                    .always(function () {
                        //alert("on always : complete");
                    });
            }
        }
    }
})();