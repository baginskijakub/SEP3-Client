var map;

function consoleLog(text){
    console.log(text)
}
 
function initialize() {
    consoleLog("1")
    var latlng = new google.maps.LatLng(55.86355730782513, 9.837627727189913);
    var options = {
        zoom: 12, center: latlng,
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
        consoleLog("CHUI");
    });
}

function toggleMap(bool)
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