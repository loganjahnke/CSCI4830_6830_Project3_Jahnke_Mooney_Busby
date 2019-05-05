// Your web app's Firebase configuration
var firebaseConfig = {
    apiKey: "AIzaSyCcE79l-VGKcTkDC0NEafqw-1dZ3YUnJjY",
    authDomain: "vr-final-project.firebaseapp.com",
    databaseURL: "https://vr-final-project.firebaseio.com",
    projectId: "vr-final-project",
    storageBucket: "vr-final-project.appspot.com",
    messagingSenderId: "1072801204255",
    appId: "1:1072801204255:web:9568cf0d8b0e2fc8"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

(function () {
    var db = firebase.database();
    var id = getUrlParameter("id");
    db.ref('employee_id/' + id + '/sessions').once('value').then(function (snapshot) {
        snapshot.forEach(function (child) {
            createRow(child);
        });
    });
})();

function createRow(snapshot) {
    var values = snapshot.val();
    var options = {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: 'numeric',
        minute: '2-digit'
    };

    var html = '<div class="row">';

    html += '<div class="cell" data-title="Session ID">';
    html += snapshot.key;
    html += '</div>';

    html += '<div class="cell" data-title="Date">';
    html += stringToDate(values.date).toLocaleDateString("en-US", options);
    html += '</div>';

    html += '<div class="cell" data-title="Dirt Collected">';
    html += values.dirt_collected;
    html += '</div>';

    html += '<div class="cell" data-title="Dirt Collected">';
    html += secondsToString(values.time_taken);
    html += '</div>';

    $('.table').append(html);
}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};

function stringToDate(_date) {
    var month = _date.substring(0, 2);
    month -= 1;
    var day = _date.substring(3, 5);
    var year = _date.substring(6, 10);
    var hour = _date.substring(11, 13);
    var min = _date.substring(15, 17);
    var formatedDate = new Date(year, month, day, hour, min);
    return formatedDate;
}

function secondsToString(seconds) {
    var str = "";
    var minutes = Math.floor(seconds / 60);
    var sec = Math.floor(seconds % 60);
    if (minutes > 60) {
        var hours = Math.floor(minutes / 60);
        var min = Math.floor(minutes % 60);
        str += hours + "h " + min + "m " + sec + "s";
    } else {
        str += minutes + "m " + sec + "s";
    }
    return str;
}