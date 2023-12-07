<template>
  <header>
    <div class="wrapper">
      <nav>
        
      </nav>
    </div>
  </header>
  <v-app>
    <v-app-bar flat>
      <v-container class="mx-auto d-flex align-center justify-center">
        <v-avatar
          class="me-4 "
          color="grey-darken-1"
          size="32"
        ></v-avatar>

        <RouterLink to="/" v-slot="{navigate}">
          <v-btn text="Home" @click="navigate"></v-btn>
        </RouterLink>
        <RouterLink to="/cart" v-slot="{navigate}">
          <v-btn text="Cart" @click="navigate"></v-btn>
        </RouterLink>
        <RouterLink to="/about" v-slot="{navigate}">
          <v-btn text="About" @click="navigate"></v-btn>
        </RouterLink>

        <v-spacer></v-spacer>

        <v-responsive max-width="160">
          <v-text-field
            density="compact"
            flat
            hide-details
            label="Search"
            rounded="lg"
            single-line
            variant="solo-filled"
          ></v-text-field>
        </v-responsive>
      </v-container>
    </v-app-bar>

    <v-main class="bg-black-lighten-1">
      <v-container>
        <RouterView/>
      </v-container>
    </v-main>
  </v-app>
</template>