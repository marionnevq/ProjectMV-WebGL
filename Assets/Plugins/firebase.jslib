mergeInto(LibraryManager.library, {

  SendEvent: function (eventName, eventData){
    var parsedEventName = Pointer_stringify(eventName);
    var parsedEventData = Pointer_stringify(eventData);
  },

  CreateUser: function(username,email,password,callback, fallback){
    var parsedUsername = Pointer_stringify(username);
    var parsedEmail = Pointer_stringify(email);
    var parsedPassword = Pointer_stringify(password);
    var parsedCallback = Pointer_stringify(callback);
    var parsedFallback = Pointer_stringify(fallback);

    window.unityfunctions.CreateUser(parsedUsername,parsedEmail,parsedPassword,parsedCallback,parsedFallback);
  },

  LoginUser: function(email,password,callback,fallback){
    var parsedEmail = Pointer_stringify(email);
    var parsedPassword = Pointer_stringify(password);
    var parsedCallback = Pointer_stringify(callback);
    var parsedFallback = Pointer_stringify(fallback);

    window.unityfunctions.LoginUser(parsedEmail,parsedPassword,parsedCallback,parsedFallback);
    console.log("email is:"+parsedEmail);
  },

  SignOut: function(callback,fallback){
    var parsedCallback = Pointer_stringify(callback);
    var parsedFallback = Pointer_stringify(fallback);
    window.unityfunctions.SignOut(parsedCallback,parsedFallback);
  },

  UploadProfilePic: function(callback,fallback){
    var parsedCallback = Pointer_stringify(callback);
    var parsedFallback = Pointer_stringify(fallback);
    window.unityfunctions.UploadProfilePic(parsedCallback,parsedFallback);
  },
  
  GetProfilePic: function(callback,fallback){
    var parsedCallback = Pointer_stringify(callback);
    var parsedFallback = Pointer_stringify(fallback);
    window.unityfunctions.GetProfilePic(parsedCallback,parsedFallback);
  }

});