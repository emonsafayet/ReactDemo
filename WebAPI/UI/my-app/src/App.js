import logo from './logo.svg';
import './App.css';
import {Home} from './Home';
import {Employee} from './Employee';
import {Department} from './Department';
import {BrowserRouter,Route,Routes,NavLink} from 'react-router-dom';


function App() {
  return (
    <BrowserRouter>
    
    <div className="App Container">
      <h3 className="d-flex justifys-content-center m-3">
          Welcome
      </h3>

      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
        <ul className="navbar-nav">

          <li className="nav-item- m-1">
          <NavLink className="btn btn-light btn-outline-rpimary" to="/home">
            Home
          </NavLink>
          </li>

          <li className="nav-item- m-1">
          <NavLink className="btn btn-light btn-outline-rpimary" to="/department">
            Department
          </NavLink>
          </li>

          <li className="nav-item- m-1">
          <NavLink className="btn btn-light btn-outline-rpimary" to="/employee">
            Employee
          </NavLink>
          </li>
        </ul>        
      </nav>   
      <Routes>
              <Route  path='/home' element={<Home/>}/>
              <Route  path='/department' element={<Department/>}/>
              <Route  path='/employee' element={<Employee/>}/>
      </Routes>   
    </div>
    </BrowserRouter>
  );
}

export default App;
