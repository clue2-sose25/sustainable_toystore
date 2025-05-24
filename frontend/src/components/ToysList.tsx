import React, { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';

interface Toy {
  id: number;
  name: string;
  categoryId: number;
}

const ToysList: React.FC = () => {
  const { categoryId } = useParams<{ categoryId: string }>();
  const [toys, setToys] = useState<Toy[]>([]);

  useEffect(() => {
    fetch(`/api/toys/category/${categoryId}`)
      .then(response => response.json())
      .then(data => setToys(data))
      .catch(error => console.error('Error:', error));
  }, [categoryId]);

  return (
    <div>
      <h1>Toys in Category {categoryId}</h1>
      <ul>
        {toys.map(toy => (
          <li key={toy.id}>
            <Link to={`/toy/${toy.id}`}>{toy.name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ToysList;