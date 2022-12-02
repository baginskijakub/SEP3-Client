var map;

function consoleLog(text){
    console.log(text)
}
 
function initialize() {
    consoleLog("1")
    var latlng = new google.maps.LatLng(40.716948, -74.003563);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    consoleLog(document.getElementById ("map"))
    const geocoder = new google.maps.Geocoder();
    map = new google.maps.Map(document.getElementById ("map"), options);

    map.addListener("click", (mapsMouseEvent) => {
        let lat = mapsMouseEvent.latLng.lat()
        let lng = mapsMouseEvent.latLng.lng()
        DotNet.invokeMethodAsync("WebApp", "setCoordinates", lat, lng)
        ConvertCoordinatesToAddress(geocoder, map, lat, lng)
    });
}

async function ConvertCoordinatesToAddress(geocoder, map, lat, lng){
    
    geocoder.geocode({
        location: {lat : lat, lng : lng}}).then(res => {
          console.log(res)
            DotNet.invokeMethodAsync("WebApp", "setAddressLine", res.results[0].formatted_address)
        })

}