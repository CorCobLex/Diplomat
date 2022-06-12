<template>
  <section>
    <b-dropdown aria-role="list">
      <template #trigger="{ active }">
        <b-button
          label="Click me!"
          type="is-primary"
          :icon-right="active ? 'menu-up' : 'menu-down'"
        />
      </template>

      <b-dropdown-item aria-role="listitem">Action</b-dropdown-item>
      <b-dropdown-item aria-role="listitem">Another action</b-dropdown-item>
      <b-dropdown-item aria-role="listitem">Something else</b-dropdown-item>
    </b-dropdown>
  </section>
</template>
<script>
// @ is an alias to /src
import HelloWorld from "@/components/HelloWorld.vue";

export default {
  name: "HomeView",
  components: {
    HelloWorld,
  },
};
</script>
