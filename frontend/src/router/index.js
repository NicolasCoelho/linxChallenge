import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Products from '../views/Products.vue'
import Product from '../views/Product.vue'
import NotFound from '../views/NotFound.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/produtos',
    name: 'Products',
    component: Products
  },
  { 
    path: '/produtos/novo', 
    name: 'NewProduct', 
    component: Product
  },
  { 
    path: '/produtos/editar/:id',
    name: 'EditProduct', 
    component: Product 
  },
  { path: '/**', component: NotFound }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
