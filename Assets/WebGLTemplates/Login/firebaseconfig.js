//Firebase Configurations

// Your web app's Firebase configuration
const firebaseConfig = {
    apiKey: "AIzaSyDKREwaL_YGixhea8efToM47olOzzrslCE",
    authDomain: "marionne-webgl-test-d9b54.firebaseapp.com",
    databaseURL: "https://marionne-webgl-test-d9b54-default-rtdb.asia-southeast1.firebasedatabase.app/",
    projectId: "marionne-webgl-test-d9b54",
    storageBucket: "marionne-webgl-test-d9b54.appspot.com",
    messagingSenderId: "1009447363276",
    appId: "1:1009447363276:web:c19d23dd21edb65730d869"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);
var database = firebase.database();
var storage = firebase.storage();
var storageRef = storage.ref();
