import { BrowserRouter, Route, Routes } from "react-router-dom";
import SummaryOrder from "../SummaryOrder/SummaryOrder";
import ShoppingList from "../ShoppingList/ShoppingList";

function Routing(): JSX.Element {
    return (
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<ShoppingList />}></Route>
                    <Route path="/summary" element={<SummaryOrder />}></Route>
                </Routes>
            </BrowserRouter>
);
}

export default Routing;
