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
    db.ref('employee_id').once('value').then(function (snapshot) {
        snapshot.forEach(function (child) {
            createRow(child);
        });
    });
})();

function createRow(snapshot) {
    var values = snapshot.val();

    var html = '<div class="row">';

    html += '<div class="cell" data-title="Employee ID">';
    if (snapshot.hasChild("sessions")) {
        html += '<a href="details.html?id=';
        html += snapshot.key;
        html += '">';
        html += snapshot.key;
        html += '</a></div>'
    } else {
        html += snapshot.key;
        html += '</div>'
    }

    html += '<div class="cell" data-title="Name">';
    html += values.name;
    html += '</div>'

    html += '<div class="cell" data-title="Training Sessions">';
    html += snapshot.hasChild("sessions") ? snapshot.child("sessions").numChildren() : 0;
    html += '</div>'

    if (snapshot.hasChild("sessions")) {
        // Find latest training date
        var maxDate = new Date(0, 0, 0);
        snapshot.child("sessions").forEach(function (child) {
            var date = stringToDate(child.val().date);
            if (date > maxDate) {
                maxDate = date;
            }
        });
        // Append a text node to the cell
        var options = {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
            hour: 'numeric',
            minute: '2-digit'
        };

        html += '<div class="cell" data-title="Last Session">';
        html += maxDate.toLocaleDateString("en-US", options);
        html += '</div>'
    } else {
        html += '<div class="cell" data-title="Last Session">';
        html += "";
        html += '</div>'
    }

    $('.table').append(html);
}

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