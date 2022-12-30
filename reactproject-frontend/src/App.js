import React, { useState, useEffect } from 'react';

const CustomerTable = (props) => {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const result = await fetch('https://localhost:7274/api/costumer');
                const data = await result.json();
                setCustomers(data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchData();
    }, []);

    return (
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Shipping Address</th>
                    <th>Billing Address</th>
                </tr>
            </thead>
            <tbody>
                {customers.map((customer) => (
                    <tr key={customer.id}>
                        <td>{customer.firstName}</td>
                        <td>{customer.lastName}</td>
                        <td>{customer.email}</td>
                        <td>
                            {customer.shippingAddress.line1 +
                                ' ' +
                                customer.shippingAddress.line2 +
                                ', ' +
                                customer.shippingAddress.city +
                                ', ' +
                                customer.shippingAddress.state +
                                ' ' +
                                customer.shippingAddress.zipCode}
                        </td>
                        <td>
                            {customer.billingAddress.line1 +
                                ' ' +
                                customer.billingAddress.line2 +
                                ', ' +
                                customer.billingAddress.city +
                                ', ' +
                                customer.billingAddress.state +
                                ' ' +
                                customer.billingAddress.zipCode}
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default CustomerTable;
