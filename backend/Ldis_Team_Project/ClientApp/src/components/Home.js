import React, { Component, useState } from 'react';
import axios from 'axios';
import { useHistory } from 'react-router-dom';
export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Welcome to your new single-page application, built with:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
        </ul>
        <p>To help you get started, we have also set up:</p>
        <ul>
          <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
          <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
          <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li>
        </ul>
            <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>

            <MyComponent />
      </div>
    );
  }
}


function MyComponent() {
    const [responseData, setResponseData] = useState(null);
    const redirectURL = 'https://localhost:44451/777';

    const handleGetRequest = async () => {
        try {
            axios.get('https://localhost:7237/api/ApiRequest')
                .then((response) => {
                    const data = response.data;
                    console.log(41, data)
                    this.setState({ data });
                    window.open(redirectURL, '_blank');
                })
                .catch((error) => {
                    console.error('Ошибка при получении данных:', error);
                });
        }
        catch
        {

        }
        
    };

    return (
        <div>
            <h1>Hello, world!</h1>
            <p>Welcome to your new single-page application.</p>
            <button onClick={handleGetRequest}>Отправить GET-запрос</button>
            {responseData && (
                <div>
                    <h2>Ответ от сервера:</h2>
                    <pre>{JSON.stringify(responseData, null, 2)}</pre>
                </div>
            )}
        </div>
    );
}

export default MyComponent;
