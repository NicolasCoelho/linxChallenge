<template>
  <div>
    <header>
     <nav class="container-fluid navbar navbar-expand-sm navbar-light bg-light justify-content-center justify-content-lg-start">
        <ul class="navbar-nav align-items-center">
          <li class="nav-item">
            <img src="/favicon.ico" width="30" class="nav-icon">
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/">Home</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/produtos">Produtos</router-link>
          </li>
        </ul>
      </nav>
    </header>
    <main>
      <router-view/>
    </main>
  </div>
</template>

<script>


export default {
  data(){
    return {
      
    }
  }
}
</script>
