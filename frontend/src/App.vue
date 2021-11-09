<template>
  <div>
    <header>
     <nav class="container-fluid navbar navbar-expand-lg navbar-light bg-light">
        <ul class="navbar-nav">
          <li class="nav-item active">
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
  },
  components: []
}
</script>

<style>

</style>
