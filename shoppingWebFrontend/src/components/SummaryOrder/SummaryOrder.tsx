import { useState } from 'react';
import { saveOrder } from '../../services/product.service';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { ProductOrder, ProductToBuy } from '../../models/product.model';
import { useLocation } from 'react-router-dom';
import { validateEmail } from '../../utils/validation';
import { useNavigate } from 'react-router-dom';

const SummaryOrder = () => {
  const location = useLocation();
  const [email, setEmail] = useState<string>('');
  const [fullName, setFullName] = useState<string>('');
  const [address, setAddress] = useState<string>('');
  const navigate = useNavigate();

  const productsToBuy: ProductToBuy[] = location.state; 

  const handleApproveOrder = async () => {
    if(!validateEmail(email) || !fullName || !address || productsToBuy?.length === 0) {
      alert('Please fill in all fields correctly');
      return;
    }
    try {
      await saveOrder({
        mail: email,
        name: fullName,
        address,
        data: productsToBuy.reduce((acc: ProductOrder, product) => {
          acc[product.id] = product.quantity;
          return acc;
        }, {})
      });

      navigate('/');
    } catch (error) {
      console.error('Failed to save order', error);
      alert('An error occurred while saving the order');
    }

  }

  return (
    <div className="container py-4">
      <div className="row mb-4 g-3">
        <div className="col-md-4">
            <input
                type="text"
                className="form-control"
                placeholder="Full Name"
                value={fullName}
                onChange={(e) => setFullName(e.target.value)}
            />
        </div>
        <div className="col-md-4">
            <input
                type="email"
                className="form-control"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
        </div>
        <div className="col-md-4">
            <input
                type="text"
                className="form-control"
                placeholder="Full Address"
                value={address}
                onChange={(e) => setAddress(e.target.value)}
            />
        </div>
        </div>
      <div className="row row-cols-1 row-cols-md-2 row-cols-lg-4 g-4 bottom">
        <div className="col-12 mx-auto">
          <div className="card h-100 border-top-0 rounded-0">
            <div className="card-body">
              <h5 className="card-title border-top pt-3">
                  Summary
              </h5>
              <ul className="list-unstyled">
                {productsToBuy.map((item, index) => (
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
      </div>
      <div className="row mb-4 g-3 mx-auto">
        <div className="col-md-3">
          <button className="btn btn-outline-primary" onClick={handleApproveOrder}>
            Approve Order
          </button>
        </div>
      </div>
    </div>
  );
};

export default SummaryOrder;