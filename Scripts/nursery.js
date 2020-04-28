const TOKEN = "pk.eyJ1IjoicWVjejEyMyIsImEiOiJjazI3NW5yYXUyMGlmM25xY294NnV0NTMwIn0.l78r_yfe9eRmxYcxgPfg_Q";

var postcode;
var url = "https://" + "api.mapbox.com/geocoding/v5/mapbox.places/nursery%20" + postcode + "%20Victoria.json?country=AU&access_token=" + TOKEN;

//set mapbox
mapboxgl.accessToken = TOKEN;
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [145, -38], // starting position
    zoom: 10
});

// Add zoom and rotation controls to the map.
map.addControl(
    new mapboxgl.NavigationControl(),

);

function findNursery() {
    var postcode = $("#postcode").val();
    url = "https://" + "api.mapbox.com/geocoding/v5/mapbox.places/nursery%20" + postcode + "%20Victoria.json?country=AU&access_token=" + TOKEN;
    // getJSON();
    console.log(url);

    // Clear existing markers
    $(".mapboxgl-marker").remove();

    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            for (var i = 0; i < data.features.length; i++) {
                console.log(data.features[i]);
                console.log(map);
                
                // map reference exists at this point
                if (data.features[i].properties.address) {
                    var marker = new mapboxgl.Marker()
                        .setLngLat(data.features[i].geometry.coordinates)
                        .setPopup(new mapboxgl.Popup({ offset: 25 }) // add popups
                            .setHTML('<h3>' + data.features[i].text + '</h3><p>' + data.features[i].properties.address + '</p>'))
                        .addTo(map);
                }
                else {
                    var marker = new mapboxgl.Marker()
                        .setLngLat(data.features[i].geometry.coordinates)
                        .setPopup(new mapboxgl.Popup({ offset: 25 }) // add popups
                            .setHTML('<h3>' + data.features[i].text + '</h3>'))
                        .addTo(map);

                }

                console.log(marker);
            }
        })
}