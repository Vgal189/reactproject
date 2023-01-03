import React from 'react';

type State = {
  products: Array<{ id: number, name: string }>
}



class HomePage extends React.Component<{}, State> {
  constructor(props : any) {
    super(props);
    this.state = {
      products: []
    }
  }

  componentDidMount() {
    // Fetch list of products from API
    fetch('https://localhost:7274/api/product')
      .then(res => res.json())
      .then(products => this.setState({ products }));
  }

  render() {
    return (
      <div>
        <h1>Welcome to our E-Commerce Site!</h1>
        <h2>Products:</h2>
        <ul>
          {this.state.products.map(product => (
            <li key={product.id}>{product.name}</li>
          ))}
        </ul>
      </div>
    );
  }
}

export default HomePage;