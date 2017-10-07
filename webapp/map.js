var lat, lng;

function initMap() {
  var map = new google.maps.Map(document.getElementById('map'), {
    center: {lat: 42.3601, lng: -71.0942}, //MIT = 42.3601° N, 71.0942 W
    zoom: 18
  });

  var drawingManager = new google.maps.drawing.DrawingManager({
    drawingMode: google.maps.drawing.OverlayType.MARKER,
    drawingControl: true,
    drawingControlOptions: {
      position: google.maps.ControlPosition.TOP_CENTER,
      drawingModes: ['marker']
    },
    markerOptions: {icon: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png'},
    circleOptions: {
      fillColor: '#ffff00',
      fillOpacity: 1,
      strokeWeight: 5,
      clickable: true,
      editable: true,
      zIndex: 1
    }
  });
  drawingManager.setMap(map);

  google.maps.event.addListener(drawingManager, 'markercomplete', function(marker) {
      drawingManager.setDrawingMode(null);
      google.maps.event.addListener(marker, 'click', function() {
        document.getElementById('myModal').style.display = "block";
        lat = marker.getPosition().lat();
        lng = marker.getPosition().lng();
        console.log('hi');
      });
  });
}

var closeModal = document.getElementsByClassName("close")[0];
closeModal.onclick = function() {
    document.getElementById('myModal').style.display = "none";
};
window.onclick = function(event) {
  console.log(event.target);
    if (event.target === modal) {
      document.getElementById('myModal').style.display = "none";
    }
};

