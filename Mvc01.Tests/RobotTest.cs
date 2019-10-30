using Mvc01.Models;
using Mvc01.Services;
using System;
using Xunit;

namespace Mvc01.Tests {

    //-- ควร เอา Class ซ้อน คลาส เพราะ Run จะเป็น method ที่เราสนใจ
    // -- ชื่อ RobotTest คือ ชื่อ  Class ที่สนใจจะเทส  Run ชื่อ method ใน Class Robot
    public class RobotTest {
        
        public class Run {

            private IPriceFeeder prices = new FakePriceFeeder(
                1180, 1179, 1178, 1177, 1176, 1175, 1174, 1173,
                1171, 1172, 1173, 1174, 1175, 1176, 1177);
            private Robot rb;

            public Run() => rb = new Robot(prices);


            //-- เทส กรณีไม่มี order 
            [Fact]
            public void FirstPrice_NoOrder() {
                //a = arrange  เตรียมของ

                //a = act  ยิง
                var order = rb.Run();

                //a = assert ตรวจสอย
                Assert.Null(order); //ตรวจสอบค่า null
            }

            //-- 
            [Fact]
            public void PriceDown3PtsFromShart_OpenShortOrder() {

                //a = arrange  เตรียมของ
                //var prices = new FakePriceFeeder(
                //    1180, 1178, 1177, 1176, 1175, 1174
                //    , 1173, 1171, 1172, 1173, 1174, 1175, 1176, 1177);
                //var rb = new Robot(prices);

                //a = act  ยิง
                rb.Run(new Price(1180));
                rb.Run(new Price(1179));
                rb.Run(new Price(1179));
                var order = rb.Run(new Price(1177));

                //a = assert ตรวจสอย
                Assert.Equal("SF @1177 x 1", order); //-- ค่าที่ได้กลับมาจะต้องเป็น SF @1177 x x1
            }

            [Fact]
            public void PriceDown3PtsFromShart_OpenAnotherShortOrder() {

                //a = arrange  เตรียมของ
                //var prices = new FakePriceFeeder(
                //    1180, 1178, 1177, 1176, 1175, 1174
                //    , 1173, 1171, 1172, 1173, 1174, 1175, 1176, 1177);
                //var rb = new Robot(prices);

                //a = act  ยิง
                rb.Run(new Price(1180));
                rb.Run(new Price(1179));
                rb.Run(new Price(1178));
                rb.Run(new Price(1177));
                rb.Run(new Price(1176));
                rb.Run(new Price(1175));
                var order = rb.Run(new Price(1174));

                //a = assert ตรวจสอย
                Assert.Equal("SF @1174 x 1", order); //-- ค่าที่ได้กลับมาจะต้องเป็น SF @1174 x x1
            }

            [Fact]
            public void PriceDown3PtsFromStart_3() {
                rb.Run(new Price(1180));
                rb.Run(new Price(1179));
                rb.Run(new Price(1178));
                var o1 = rb.Run(new Price(1177));

                var o2 = rb.Run(new Price(1178));
                var o3 = rb.Run(new Price(1177));

                var o4 = rb.Run(new Price(1176));
                var o5 = rb.Run(new Price(1175));
                var o6 = rb.Run(new Price(1174));

                Assert.Equal("SF @1177 x 1", o1);
                Assert.Null(o3);
                Assert.Null(o5);
                Assert.Equal("SF @1174 x 1", o6);
            }

            [Fact]
            public void DownAndUp() {
                rb.Run(new Price(1180));
                rb.Run(new Price(1177));
                rb.Run(new Price(1174));
                rb.Run(new Price(1171));
                rb.Run(new Price(1170));
                var o1 = rb.Run(new Price(1175));
                var o2 = rb.Run(new Price(1176));

                Assert.Null(o1);
                Assert.Equal("LF @1176 x 1", o2);
            }

            [Fact]
            public void DownAndUpAndUp() {
                rb.Run(new Price(1180));
                rb.Run(new Price(1177));
                rb.Run(new Price(1174));
                rb.Run(new Price(1171));
                rb.Run(new Price(1170));
                rb.Run(new Price(1175));
                rb.Run(new Price(1176));
                rb.Run(new Price(1177));
                rb.Run(new Price(1178));
                var o1 = rb.Run(new Price(1179));

                Assert.Equal("LF @1179 x 1", o1);
            }

            // -- เทศเรื่องของการ throws 
            [Fact]
            public void NegativePrice_ThrowsException() {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                    rb.Run(new Price(-50));
                });
                Assert.Contains("-50", ex.Message);
            }

            //-- เทส แบบ Parameter จะต้อง ใส่หัว ตามนี้
            [Theory]
            [InlineData(1180,1177,"SF @1177 x 1")]
            public void SecondShots(double p1, double p2, string order) {
                var o1 = rb.Run(new Price(p1));
                var o2 = rb.Run(new Price(p2));

                Assert.Equal(order, o2);
            }

            // -- หากอยากข้าม test ไหน ให้ใส่ตามนี้
            [Fact(Skip = "ทดสอบการ Script Test")]
            public void TestComment() {

            }

        }
    }
}
