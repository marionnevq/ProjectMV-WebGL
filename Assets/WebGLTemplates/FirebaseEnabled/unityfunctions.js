var unityfunctions = {

    CreateUser: function (username, email, password, callback, fallback) {

        var onValueChange = function (snapshot) {
            if (snapshot.exists()) {
                var name = JSON.stringify(snapshot.val());
                console.log("The username " + name + "already exists");
                window.unityInstance.SendMessage("EventManager", fallback, "username is in use");
            } else {
                console.log("username is new.");
                firebase.auth().createUserWithEmailAndPassword(email, password).then(function (data) {
                    //update User's username
                    data.user.updateProfile({
                        displayName: username.toString(),
                        photoURL: null
                    }).then(
                        function () {
                            //send back to unity the usernam
                            var displayName = data.user.displayName;
                            window.unityInstance.SendMessage("EventManager", callback, "User Registered with username: " + displayName);
                            unityfunctions.CreateRecord(username, email, data.user.uid);
                            unityfunctions.SendVerificationEmail();
                        },
                        function (error) {
                            window.unityInstance.SendMessage("EventManager", fallback, "There was an error: " + error.message);
                        }
                    );
                }).catch(function (error) {
                    window.unityInstance.SendMessage("EventManager", fallback, "There was an error: " + error.message);
                });
            }
        }

        firebase.database().ref('app').child('users').orderByChild('username').equalTo(username).once('value').then(onValueChange);


    },

    LoginUser: function (email, password, callback, fallback) {

        //sign in User
        firebase.auth().signInWithEmailAndPassword(email, password).then(function () {
            var unsubscribe = firebase.auth().onAuthStateChanged((user) => {
                if (user) {
                    // User is signed in
                    var username = user.displayName;
                    console.log("signed in " + username);
                    window.unityInstance.SendMessage("EventManager", callback, username + ":" + user.emailVerified);
                }

            });

            unsubscribe();

        }).catch(function (error) {
            window.unityInstance.SendMessage("EventManager", fallback, "There was an error: " + error.message);
        });


    },

    CreateRecord: function (username, email, uid) {


        firebase.database().ref('app/users/' + uid).set({
            username: username,
            email: email
        });

    },

    CheckUsername: function (username) {
        var isUnique = false;
        var onValueChange = function (snapshot) {
            if (snapshot.exists()) {
                var name = JSON.stringify(snapshot.val());
                console.log("The username " + name + "already exists");

            } else {
                console.log("username is new.");

            }
        }
        firebase.database().ref('app').child('users').orderByChild('username').equalTo(username).on('value', onValueChange)
    },



    SendVerificationEmail: function () {

        var actionCodeSettings = {
            // URL you want to redirect back to. The domain (www.example.com) for this
            // URL must be in the authorized domains list in the Firebase Console.
            url: 'https://marionne-webgl-test-d9b54.firebaseapp.com/',
            // This must be true.
            handleCodeInApp: true,
        }

        firebase.auth().currentUser.sendEmailVerification(actionCodeSettings)
            .then(function () {
                console.log("please check email");
            })
            .catch(function (error) {
                console.log(error.message);
            });
    },

    SignOut: function (callback, fallback) {
        firebase.auth().signOut().then(() => {
            // Sign-out successful.
            console.log("user signed out");
            window.unityInstance.SendMessage("EventManager", callback, "successfully signed out");

        }).catch((error) => {
            console.log("user sign out failed");
            //window.unityInstance.SendMessage("EventManager", fallback, "hehe");

        });
    },

    UploadProfilePic: function (callback, fallback) {
        
        var image = {};
        var user = firebase.auth().currentUser;
        modal_container.classList.add('show');
        //var input = document.createElement('input');
        //input.type = 'file';
        //input.click();
        /*
        input.onchange = e => {
            image = e.target.files[0];

            firebase.storage().ref('users/' + user.uid + '/profile.jpg').put(image).then(function () {
                console.log('upload success');

                firebase.storage().ref('users/' + user.uid + '/profile.jpg').getDownloadURL().then((url) => {
                    window.unityInstance.SendMessage("EventManager", callback, url);
                })

            }).catch(error => {
                console.log(error.message);
                window.unityInstance.SendMessage("EventManager", fallback, error.message);

            });
        }*/
    },

    GetProfilePic: function (callback, fallback) {
        var user = firebase.auth().currentUser;

        firebase.storage().ref('users/' + user.uid + '/profile.jpg').getDownloadURL().then((url) => {
            window.unityInstance.SendMessage("EventManager", callback, url);
        }).catch(error => {
            window.unityInstance.SendMessage("EventManager", fallback, error.message);

        })
    }
}
