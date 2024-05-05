<template>
  <transition name="fade">
    <div v-if="show" :class="`p-4 rounded fixed bottom-4 right-4 text-white ${bgColor}`">
      {{ message }}
      <button class="ml-4" @click="close">X</button>
    </div>
  </transition>
</template>

<script setup>
import { ref } from 'vue';

const show = ref(false);
const message = ref("");
const bgColor = ref("bg-green-500"); // Mặc định là màu xanh cho thành công

function close() {
  show.value = false;
}

function notify(msg, success = true) {
  message.value = msg;
  bgColor.value = success ? "bg-green-500" : "bg-red-500"; // Xanh cho thành công, đỏ cho thất bại
  show.value = true;
  setTimeout(() => {
    show.value = false;
  }, 3000);  // Thông báo tự động tắt sau 3 giây
}
</script>

<style>
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
</style>
