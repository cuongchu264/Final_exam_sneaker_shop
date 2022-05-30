<template>
    <main>
    <body>
        <form class="login-form mt-5" action="./" method="POST"  @submit.prevent="onSubmit">
            <div class="login-form__content">
                <div class="text-center">
                    <img  src="https://i.pinimg.com/originals/75/ee/39/75ee392159be8a3e25094c94ae7e03d4.gif" width="160" height="140" alt="">
                </div>
                <div class="login-form__header">ĐĂNG NHẬP</div>
                    <input class="login-form__input" type="text" name="dc_username"  v-model="dataSubmit.username"  placeholder="Username" required>
                    <input class="login-form__input" type="password" name="dc_username" v-model="dataSubmit.password" placeholder="Password" required>
                <button class="login-form__button" type="submit">Đăng nhập</button>
                <div class="has-text-centered" style="margin-top: 20px">
                  <p>
                    Bạn chưa có tài khoản? <nuxt-link to="/register">Đăng kí ngay</nuxt-link>
                  </p>
              </div>
            </div>
        </form>
    
    </body>
    <style>
        body{
            background-image: url('https://i.pinimg.com/736x/b9/f9/cb/b9f9cbf47532518f6f1c2b7191e56da1.jpg');"
        }
        .login-form,
        .login-form * {
            box-sizing: border-box;
            font-family: 'Source Sans Pro';
        }

        .login-form {
            max-width: 350px;
            margin: 0 auto;
            border-radius: 5px;
            overflow: hidden;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.15);
        }

        .login-form__logo-container {
            padding: 30px;
            background: rgba(0, 0, 0, 0.25);
        }

        .login-form__logo {
            display: block;
            max-width: 125px;
            margin: 0 auto;
        }

        .login-form__content {
            padding: 30px;
            background: white;
            
        }

        .login-form__header {
            margin-bottom: 15px;
            text-align: center;
            color: #333333;
            font-weight: bold;
            font-size: 25px;
        }

        .login-form__input {
            width: 100%;
            margin-bottom: 10px;
            padding: 10px;
            border-radius: 5px;
            border: 2px solid #dddddd;
            background: white;
            outline: none;
            transition: border-color 0.5s;
        }

        .login-form__input:focus {
            border-color: white;
        }

        .login-form__input::placeholder {
            color: #aaaaaa;
        }

        .login-form__button {
            padding: 10px;
            color: #ffffff;
            font-weight: bold;
            background: #009578;
            width: 100%;
            border: none;
            outline: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .login-form__button:active {
            background: #008067;
        }

        .login-form__links {
            margin-top: 15px;
            text-align: center;
        }

        .login-form__link {
            font-size: 0.9em;
            color: #008067;
            text-decoration: none;
        }

    </style>
    </main>
</template>
<script>
import { mapActions } from 'vuex'
import accountApi from '@/api/accountApi'
import Notification from '~/components/Nofication.vue'
export default {
    layout:'ordersuccesslayout',
    components: {
    Notification,
  },
  data() {
    return {
      dataSubmit: {
        username: '',
        password: '',
      },
    }
  },
  methods: {
    ...mapActions({
      setToken: 'user/setToken',
      setName: 'user/setName',
      setBranch: 'user/setBranch'
    }),
    async onSubmit() {
      try {
          const data = await accountApi.login(this.$axios, this.dataSubmit)
          console.log(data.access_token)
          await this.setToken(data.access_token)
          await this.setName(data.name)
          await this.setBranch(data.branch)
          this.$router.push('/home')
          alert('Đăng nhập thành công!')
      } catch (err) {
          console.log(err)
          alert('Sai tên đăng nhập hoặc mật khẩu')
      }
    },
  },
}
</script> 