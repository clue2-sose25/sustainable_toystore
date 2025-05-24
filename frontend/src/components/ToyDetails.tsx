import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

interface Toy {
  id: number;
  name: string;
  categoryId: number;
}

const ToyDetails: React.FC = () => {
  const { toyId } = useParams<{ toyId: string }>();
  const [toy, setToy] = useState<Toy | null>(null);

  useEffect(() => {
    fetch(`/api/toys/${toyId}`)
      .then(response => response.json())
      .then(data => setToy(data))
      .catch(error => console.error('Error:', error));
  }, [toyId]);

  if (!toy) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>{toy.name}</h1>
      <p>Category ID: {toy.categoryId}</p>
    </div>
  );
};

export default ToyDetails;