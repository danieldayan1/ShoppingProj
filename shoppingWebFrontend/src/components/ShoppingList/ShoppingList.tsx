import { useEffect, useState } from 'react';
import { Search } from 'lucide-react';
import { getProducts } from '../../services/product.service';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import './ShoppingList.css';
import { ProductToBuy, ProductsByCategory, ProductsToBuyByCategory } from '../../models/product.model';
import { useNavigate } from 'react-router-dom';

const ShoppingList = () => {
  const [categories, setCategories] = useState<string[]>([]);
  const [selectedCategory, setSelectedCategory] = useState<string>('');
  const [products, setProducts] = useState<ProductsByCategory>({});
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [totalItems, setTotalItems] = useState<number>(0);
  const [searchTerm, setSearchTerm] = useState('');
  const [productsToBuy, setProductsToBuy] = useState<ProductsToBuyByCategory>({});
  const [quantity, setQuantity] = useState<number>(1);
  const navigate = useNavigate();

  const getAllItems = (): ProductToBuy[] => {
    const items = [];
    for (const category in productsToBuy) {
        items.push(...productsToBuy[category]);
    }

    return items;
  }

  const handleAddProduct = () => {
      if (!selectedCategory || !searchTerm || quantity < 1) {
        alert('Please select a category, product and quantity');
        return;
      };

      const productIndex = products[selectedCategory].find(product => product.product_name === searchTerm);

      if (productIndex) {
          const currProductToBuy = productsToBuy
          currProductToBuy[selectedCategory] = currProductToBuy[selectedCategory] || [];
          const product = currProductToBuy[selectedCategory].find(product => product.id === productIndex.product_id);

          if(product) {
              product.quantity += quantity;
          } else {
              currProductToBuy[selectedCategory].push({ name: searchTerm, quantity, id: productIndex.product_id });
          }

          setProductsToBuy(currProductToBuy);
          setTotalItems(totalItems + quantity);
          setSearchTerm('');
          setQuantity(1);
      }
  };

  const fetchData = async () => {
      try {
          const products = await getProducts() as ProductsByCategory;
          const categories = Object.keys(products);

          setCategories(categories);
          setProducts(products);
          setSelectedCategory(categories[0]);
      } catch (err) {
          setError('Failed to fetch shopping list data');
      } finally {
          setIsLoading(false);
      }
    };
    
  useEffect(() => {
      setIsLoading(true);
      fetchData();
  }, []);

  if (isLoading) return <div className="p-4">Loading...</div>;
  if (error) return <div className="p-4 text-red-500">{error}</div>;

  return (
    <div className="container py-4">
      <div className="row mb-4">
        <div className="col">
          <h1 className="h2 text-primary">Shopping list</h1>
          <p className="text-muted">Total: {totalItems}</p>
        </div>
      </div>
      <div className="row mb-4 g-3">
        <div className="col-md-3">
          <div className="dropdown">
            <select 
              className="form-select"
              value={selectedCategory}
              onChange={(e) => setSelectedCategory(e.target.value)}
            >
              {categories.map(category => (
                <option key={category} value={category}>
                  {category}
                </option>
              ))}
            </select>
          </div>
        </div>

        <div className="col-md-3">
          <div className="position-relative">
            <div className="input-group">
              <span className="input-group-text">
                <Search size={18} />
              </span>
              <input
                type="text"
                className="form-control"
                placeholder="Search product..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
              />
            </div>
            
            {searchTerm && (
              <div className="position-absolute top-100 start-0 w-100 mt-1 override">
                <ul className="list-group shadow-sm">
                  {products[selectedCategory]
                    .filter(product => 
                      product.product_name.toLowerCase().includes(searchTerm.toLowerCase())
                    )
                    .map(product => (
                      <li 
                        onClick={() => setSearchTerm(product.product_name)}
                        key={product.product_name} 
                        className="list-group-item list-group-item-action"
                      >
                        {product.product_name}
                      </li>
                    ))}
                </ul>
              </div>
            )}
                    
          </div>
        </div>
        <div className="col-md-3">
            <input
                type="number"
                className="form-control"
                placeholder="Amount"
                min={1}
                max={30}
                value={quantity}
                onChange={(e) => setQuantity(Number(e.target.value))}
            />
        </div>
        <div className="col-md-3">
          <button className="btn btn-outline-primary" onClick={handleAddProduct}>
            Add
          </button>
        </div>
      </div>
      <div className="row row-cols-1 row-cols-md-2 row-cols-lg-4 g-4 bottom">
        {Object.entries(productsToBuy).map(([category, items]) => (
          <div key={category} className="col">
            <div className="card h-100 border-top-0 rounded-0">
              <div className="card-body">
                <h5 className="card-title border-top pt-3">
                  {category}- ({items.reduce((acc, currItem) => acc + currItem.quantity, 0)})
                </h5>
                <ul className="list-unstyled">
                  {items.map((item, index) => (
                    <li key={index} className="mb-2">
                      {item.name} {item.quantity > 1 && 
                        <span className="badge bg-secondary">
                          {item.quantity}
                        </span>
                      }
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          </div>
        ))}
      </div>

      <div className="col-md-3">
          <button className="btn btn-outline-primary" onClick={() => navigate('/summary', { state: getAllItems() })
          }>
            Finish Order
          </button>
        </div>  
    </div>
  );
};

export default ShoppingList;