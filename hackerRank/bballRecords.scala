import java.io._
import java.math._
import java.security._
import java.text._
import java.util._
import java.util.concurrent._
import java.util.function._
import java.util.regex._
import java.util.stream._
import scala.collection.immutable._
import scala.collection.mutable._
import scala.collection.concurrent._
import scala.concurrent._
import scala.io._
import scala.math._
import scala.sys._
import scala.util.matching._
import scala.reflect._

object Result {
    def breakingRecords(scores: Array[Int]): Array[Int] = {
        var min = scores.head
        var max = scores.head
        var brokenMins = 0
        var brokenMax = 0
        scores.foreach{ score =>
            if (brokeMinRecord(score, min)) {
                min = score
                brokenMins = brokenMins + 1
            }
            else if (brokeMaxRecord(score, max)) {
                max = score
                brokenMax = brokenMax + 1
            }
        }
        Array(brokenMax, brokenMins)
    }
    
    def brokeMinRecord(score: Int, min: Int): Boolean = {
        score < min
    }
    
    def brokeMaxRecord(score: Int, max: Int): Boolean = {
        score > max
    }
}

object Solution {
    def main(args: Array[String]) = {
        val result = Result.breakingRecords(Array(3,4,21,36,10,28,35,5,24,42))
        printf("" + result.head + ", " + result.last)
    }
}
