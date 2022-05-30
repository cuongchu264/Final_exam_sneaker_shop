<template>
    <div class="container">
<div class="container bootstrap snippets bootdeys">
      <h2 class="text-center mt-2">HỖ TRỢ KHÁCH HÀNG 24/7</h2>
      <div class="row text-center">
      </div>
        <div class="row">
          <div class="col-sm-3">
            <div class="contact-map"> 
            </div>
          </div>         
        <div class="col-sm-6">
           <Notification v-if="error" :message="error"/>
          <form role="form" name="ajax-form" id="ajax-form"   @submit.prevent="AddCustomerSP" method="post" class="form-main">

            <div class="form-group">
              <label for="name2">Tên</label>
              <input 
              class="form-control" 
              id="name2" name="name" 
              type="text" value="Name"
              v-model="dataSubmit.CustomerSPName" required>
              
            </div> <!-- /Form-name -->

            <div class="form-group">
              <label for="email2">Email</label>
              <input class="form-control" 
               v-model="dataSubmit.CustomerSPEmail"
              id="email2" name="email" type="text" 
              value="E-mail"
               required >
           
            </div> <!-- /Form-email -->
            <div class="form-group">
              <label for="email2">Phone</label>
              <input class="form-control" 
               v-model="dataSubmit.CustomerSPPhone"
              id="email2" name="email" type="text" 
              value="E-mail"
               required >
           
            </div> <!-- /Form-email -->
            <div class="form-group">
              <label for="message2">Lời nhắn</label>
              <textarea 
               v-model="dataSubmit.customerSPDescriptions"
              class="form-control" id="message2" name="message" rows="5" required>Lời nhắn</textarea>

              
            </div> <!-- /col -->
             <div class="form-group"  v-if="UserName.branch == 1" >
               <span>Chi nhánh cửa hàng:</span>
                    <br>
                      <input id="one" type="radio" name="dc_branch" value=1  v-model="dataSubmit.branchId"  required>
                      <label for="one">Đà Nẵng</label>
                    <br>

             </div>
               <div class="form-group" v-if="UserName.branch == 2" >
               <span>Chi nhánh cửa hàng:</span>

                    <br>
                      <input id="two" type="radio" name="dc_branch" value=2  v-model="dataSubmit.branchId"  required>
                      <label for="two">Sài Gòn</label>
                    <br>
             </div>
            <div class="form-group"  v-if="!UserName.username" >
               <span>Chi nhánh cửa hàng:</span>
                    <br>
                      <input id="one" type="radio" name="dc_branch" value=1  v-model="dataSubmit.branchId"  required>
                      <label for="one">Đà Nẵng</label>
                    <br>
                      <input id="two" type="radio" name="dc_branch" value=2  v-model="dataSubmit.branchId"  required>
                      <label for="two">Sài Gòn</label>
                    <br>
            </div>


            <div class="row">   
                 <div class="col-sm-5">
            </div>         
              <div class="col-sm-19">
                <button type="submit" class="btn btn-success" id="send">SUBMIT</button> 
              </div> 
            </div>

          </form>
        </div> 

      </div> 
          
    </div>

    </div>
</template>
<script>
import catalogApi from '@/api/catalogApi'
export default {
    components: {
    Notification,
  },
 data(){
        this.UserName = JSON.parse(localStorage.getItem("user"))
        return{
          dataSubmit:{
                customerSPname: '',
                customerSPemail: '',
                customerSPDescriptions: '',
                CustomerSPPhone: '',
                branchId: 0,
                
          },
          UserName:'',
           error: null,
        }
    },
        async created(){


    },
   mounted() {
        if (localStorage.getItem("user")){
            this.UserName = JSON.parse(localStorage.getItem("user"))
        }
    },
    methods:{


       async AddCustomerSP() {
       try {
       await catalogApi.addCustomment(this.$axios, this.dataSubmit)
        alert("Phản hổi của bạn được ghi nhận !")
        this.$router.push('/success')
       
       } catch (err) {
        alert('Có lỗi xảy ra, vui lòng thử lại.' + JSON.stringify(err))
       }

     }
}

}
</script>
<style>

</style>