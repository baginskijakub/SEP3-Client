let map;

function consoleLog(text){
    console.log(text)
}
 
export function initialize() {
    var latlng = new google.maps.LatLng(40.716948, -74.003563);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById ("map"), options);

    map.addListener("click", (mapsMouseEvent) => {

        console.log(mapsMouseEvent.latLng)
    });
}

function getCoordinatesOnClick(){

}