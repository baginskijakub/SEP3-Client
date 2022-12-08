var map;

function consoleLog(text){
    console.log(text)
}
 
window.initialize = function initialize() {
    var mapStyle = [
        {
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#1d2c4d"
                }
            ]
        },
        {
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#8ec3b9"
                }
            ]
        },
        {
            "elementType": "labels.text.stroke",
            "stylers": [
                {
                    "color": "#1a3646"
                }
            ]
        },
        {
            "featureType": "administrative",
            "elementType": "geometry",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "administrative.country",
            "elementType": "geometry.stroke",
            "stylers": [
                {
                    "color": "#4b6878"
                }
            ]
        },
        {
            "featureType": "administrative.land_parcel",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "administrative.land_parcel",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#64779e"
                }
            ]
        },
        {
            "featureType": "administrative.province",
            "elementType": "geometry.stroke",
            "stylers": [
                {
                    "color": "#4b6878"
                }
            ]
        },
        {
            "featureType": "landscape.man_made",
            "elementType": "geometry.stroke",
            "stylers": [
                {
                    "color": "#334e87"
                }
            ]
        },
        {
            "featureType": "landscape.natural",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#023e58"
                }
            ]
        },
        {
            "featureType": "poi",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "poi",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#283d6a"
                }
            ]
        },
        {
            "featureType": "poi",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#6f9ba5"
                }
            ]
        },
        {
            "featureType": "poi",
            "elementType": "labels.text.stroke",
            "stylers": [
                {
                    "color": "#1d2c4d"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "geometry.fill",
            "stylers": [
                {
                    "color": "#023e58"
                }
            ]
        },
        {
            "featureType": "poi.park",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#3C7680"
                }
            ]
        },
        {
            "featureType": "road",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#304a7d"
                }
            ]
        },
        {
            "featureType": "road",
            "elementType": "labels.icon",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "road",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#98a5be"
                }
            ]
        },
        {
            "featureType": "road",
            "elementType": "labels.text.stroke",
            "stylers": [
                {
                    "color": "#1d2c4d"
                }
            ]
        },
        {
            "featureType": "road.highway",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#2c6675"
                }
            ]
        },
        {
            "featureType": "road.highway",
            "elementType": "geometry.stroke",
            "stylers": [
                {
                    "color": "#255763"
                }
            ]
        },
        {
            "featureType": "road.highway",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#b0d5ce"
                }
            ]
        },
        {
            "featureType": "road.highway",
            "elementType": "labels.text.stroke",
            "stylers": [
                {
                    "color": "#023e58"
                }
            ]
        },
        {
            "featureType": "road.local",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "transit",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "transit",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#98a5be"
                }
            ]
        },
        {
            "featureType": "transit",
            "elementType": "labels.text.stroke",
            "stylers": [
                {
                    "color": "#1d2c4d"
                }
            ]
        },
        {
            "featureType": "transit.line",
            "elementType": "geometry.fill",
            "stylers": [
                {
                    "color": "#283d6a"
                }
            ]
        },
        {
            "featureType": "transit.station",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#3a4762"
                }
            ]
        },
        {
            "featureType": "water",
            "elementType": "geometry",
            "stylers": [
                {
                    "color": "#0e1626"
                }
            ]
        },
        {
            "featureType": "water",
            "elementType": "labels.text.fill",
            "stylers": [
                {
                    "color": "#4e6d70"
                }
            ]
        }
    ]
    consoleLog("1")
    var latlng = new google.maps.LatLng(55.86355730782513, 9.837627727189913);
    var options = {
        zoom: 12, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoomControl: true,
        mapTypeControl: false,
        scaleControl: false,
        streetViewControl: false,
        rotateControl: false,
        fullscreenControl: false,
        styles: mapStyle
    };
    
    consoleLog(document.getElementById ("map"))
    const geocoder = new google.maps.Geocoder();
    map = new google.maps.Map(document.getElementById ("map"), options);

    map.addListener("click", (mapsMouseEvent) => {
        let lat = mapsMouseEvent.latLng.lat()
        let lng = mapsMouseEvent.latLng.lng()
        DotNet.invokeMethodAsync("WebApp", "setCoordinates", lat, lng)
        ConvertCoordinatesToAddress(geocoder, map, lat, lng)
        consoleLog("CHUI");
    });
}

window.toggleMap = function toggleMap(bool)
{
    if(bool)
    {
        document.getElementById("map").style.display = "flex";
    }
    else
    {
        document.getElementById("map").style.display = "none";
    }
}

async function ConvertCoordinatesToAddress(geocoder, map, lat, lng){
    
    geocoder.geocode({
        location: {lat : lat, lng : lng}}).then(res => {
          console.log(res)
            DotNet.invokeMethodAsync("WebApp", "setAddressLine", res.results[0].formatted_address)
        document.getElementById("AddressLine").innerHTML=res.results[0].formatted_address;
        let country = "";
        let streetNo = "";
        let city = "";
        let zipCode = "";
        let streetName = "";
        
        res.results[0].address_components.forEach(component => {
            component.types.forEach(type => {
                if(type === "street_number")
                {
                    streetNo = component.long_name;
                }
                if(type === "country")
                {
                    country = component.short_name;
                }
                if(type === "locality")
                {
                    city = component.long_name;
                }
                if(type === "postal_code")
                {
                    zipCode = component.long_name;
                }
                if(type === "route")
                {
                    streetName = component.long_name;
                }
            })
        })
        //consoleLog(country);
        let locationTemp = 
        {
            Country : country,
            City : city,
            StreetName : streetName + " " + streetNo,
            ZipCode : zipCode,
            CoordinatesX : lat,
            CoordinatesY : lng
        }
        DotNet.invokeMethodAsync("WebApp", "setLocation", country, city, streetName + " " + streetNo,
            zipCode, lat, lng)
        })
    
}

function clearAddress()
{
    document.getElementById("AddressLine").innerHTML="";
}