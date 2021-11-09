<template>
  <div>
    <header>
      <Nav/>
    </header>
    <main>
      <router-view/>
    </main>
  </div>
</template>

<script>
import Nav from './components/Nav.vue';

export default {
  data(){
    return {
      
    }
  },
  components: [Nav]
}
</script>

<style>

</style>
