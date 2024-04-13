<template>
  <div id="main-banner"></div>
</template>

<script setup>
import burger from "@/assets/burger.jpg";

const msg = 'Hello from Banner';

const mainBannerStyle = {
  backgroundImage: `url(${burger})`,
  margin: '-3.1em',
  backgroundPosition: '0',
  backgroundSize: 'cover',
  objectFit: 'cover',
  height: '325px',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'flex-start',
};
</script>

<style scoped>
#main-banner {
  background-image: url("@/assets/burger.jpg");
  margin: -3.1em;
  background-position: 0;
  background-size: cover;
  object-fit: cover;
  height: 325px;
  display: flex;
  align-items: center;
  justify-content: flex-start;
}
</style>
