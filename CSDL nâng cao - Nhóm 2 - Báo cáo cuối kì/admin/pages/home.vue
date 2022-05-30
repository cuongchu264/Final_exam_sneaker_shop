<template>
  <main>
    <div class="container">
      <div class="admin-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
        <h1 class="display-4">TRANG QUẢN LÍ SNEAKER SHOP</h1>
        <p class="lead">“Cái người đời thường thiếu là ý chí chứ không phải là sức mạnh” – Victor Hugo</p>
        <img src="https://i.pinimg.com/originals/75/ee/39/75ee392159be8a3e25094c94ae7e03d4.gif" alt="">
      </div>
    </div>
  </main>   
</template>

<script>
export default {
  layout: 'default',
  middleware: ['isAuthorize'],
}
</script>
