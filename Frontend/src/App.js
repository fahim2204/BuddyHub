import React, { Component } from 'react'
import FacebookLogin from 'react-facebook-login';
import GoogleLogin from 'react-google-login'

export class App extends Component {

  responseGoogle = (response) => {
    console.log(response);
    console.log(response.profileObj);
  }
  responseFacebook = (response) => {
    console.log(response);
  }

  render() {
    return (
      <div>
        <GoogleLogin
        clientId="197200157088-jok25uj7eb4dm1jhdie8f5cth1kntimu.apps.googleusercontent.com"
        buttonText="Login"
        onSuccess={this.responseGoogle}
        onFailure={this.responseGoogle}
        cookiePolicy={'single_host_origin'}
        />
       
        <FacebookLogin
    appId="408009050991275"
    autoLoad={false}
    fields="name,email,picture"
    onClick={this.componentClicked}
    callback={this.responseFacebook}
    reAuthenticate={true} />
      </div>
    )
  }
}

export default App
