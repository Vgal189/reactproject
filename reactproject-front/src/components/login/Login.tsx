import React from 'react';

type LoginState = {
  email: string,
  password: string,
}

class LoginForm extends React.Component<{}, LoginState> {
  constructor(props : any) {
    super(props);
    this.state = {
      email: '',
      password: '',
    };
  }

  handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    this.setState({ [name]: value } as Pick<LoginState, keyof LoginState>);
  }

  showData = () => {
    console.log(this.state)
  }

  handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const { email, password } = this.state;
    fetch('https://localhost:7274/api/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ email, password })
    })
      .then(res => {
        if (res.ok) {
          return res.json();
        }
        throw new Error('Error logging in');
      })
      .then(data => {
        console.log(data);
        this.showData();
      })
      .catch(error => {
        console.error(error);
      });
  }

  render() {
    const { email, password} = this.state;
    return (
      <form onSubmit={this.handleSubmit}>
        <label htmlFor="email">Email:</label>
        <input
          type="email"
          id="email"
          name="email"
          value={email}
          onChange={this.handleChange}
          required
        />
        <label htmlFor="password">Password:</label>
        <input 
          type="password"
          id="password"
          name="password"
          value={password}
          onChange={this.handleChange}
          required
        />
        <button type="submit">Log in</button>
      </form>
    );
  }
}

export default LoginForm;