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

function addToFirebase() {
    var db = firebase.database();
    var id = $("#id").val();
    var name = $("#name").val();
    db.ref("employee_id/" + id).set({
        name: name
    }).then(function() {
        window.location.href = "index.html";
    });
}