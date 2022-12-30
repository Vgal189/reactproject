import React, { useState, useEffect } from 'react';

const PersonTable = () => {
  const [persons, setPersons] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await fetch('https://localhost:7274/api/person');
      const data = await result.json();
      setPersons(data);
    };

    fetchData();
  }, []);

  return (
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Phone</th>
          <th>Age</th>
          <th>ID</th>
        </tr>
      </thead>
      <tbody>
        {persons.map(person => (
          <tr key={person.id}>
            <td>{person.name}</td>
            <td>{person.phone}</td>
            <td>{person.age}</td>
            <td>{person.id}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default PersonTable;
