<template>
  <div id="main-banner"></div>
</template>

<script>
import burger from "@/assets/burger.jpg";
export default {
  name: "Banner",
  data() {
    return {
      burger: burger,
    };
  },
  props: {
    msg: String,
  },
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
